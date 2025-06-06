﻿using Application.Contracts.Label;
using Application.Contracts.LabelType;
using Application.Execution.Hall;
using Application.Execution.Label;
using Application.Execution.LabelType;
using Application.Execution.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presention.PrintModel;
using System.Globalization;

using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using WinFormNafisNakh;

namespace Presention.Pages
{
    public class PrintModel : PageModel
    {
        //برای شناسایی نام پرینتر پیشفرض ویندوز
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int pcchBuffer);
        
        
        
        
        static string GetDefaultPrinterName()
        {
            int bufferSize = 256;
            StringBuilder buffer = new StringBuilder(bufferSize);
        
            if (GetDefaultPrinter(buffer, ref bufferSize))
            {
                return buffer.ToString();
            }
            else
            {
                return "هیچ پرینتری تنظیم نشده است!";
            }
        }



        //برای شناسایی نام پرینتر پیشفرض شبکه

        // public static string GetDefaultPrinterName()
        // {
        //     ProcessStartInfo psi = new ProcessStartInfo
        //     {
        //         FileName = "powershell",
        //         Arguments = "Get-Printer | Where-Object {$_.IsDefault -eq $true} | Select-Object -ExpandProperty Name",
        //         RedirectStandardOutput = true,
        //         UseShellExecute = false,
        //         CreateNoWindow = true
        //     };
        //
        //     using (Process process = Process.Start(psi))
        //     {
        //         process.WaitForExit();
        //         return process.StandardOutput.ReadToEnd().Trim();
        //     }
        // }



        public static string ToPersianDate(DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return $"{persianCalendar.GetYear(date)}/{persianCalendar.GetMonth(date):00}/{persianCalendar.GetDayOfMonth(date):00}";
        }


        

        private readonly ILabelApplication _labelApplication;
        private readonly ILabelTypeApplication _labelTypeApplication;
        private readonly IMachineApplication _machineApplication;
        private readonly IHallApplication _hallApplication;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PrintModel(ILabelApplication labelApplication, ILabelTypeApplication labelTypeApplication, IMachineApplication machineApplication, IHallApplication hallApplication, IWebHostEnvironment webHostEnvironment)
        {
            _labelApplication = labelApplication;
            _labelTypeApplication = labelTypeApplication;
            _machineApplication = machineApplication;
            _hallApplication = hallApplication;
            _webHostEnvironment = webHostEnvironment;
        }

        public string DefaultPrinterName { set; get; }
        public EditLabel LabelView { get; set; }
        public List<LabelTypeViewModel> LabelTypeView { get; set; }
        public long HallID { get; set; }
        public void OnGet(long id)
        {

            DefaultPrinterName = GetDefaultPrinterName();
            LabelView = _labelApplication.GetDetails(id);
             HallID= _machineApplication.GetDetails(LabelView.MachineID).HallID;
            LabelTypeView = _labelTypeApplication.Search(new LabelTypeSerachModel
            {
                HallID = HallID
            }).Where(x=>x.IsRemove==false).ToList();
        }

        public IActionResult OnPost(PrintModelOutput command)
        {
            string dateTime;
            string fileContent;
            string HallName = _hallApplication.GetDetails(_machineApplication.GetDetails(command.MachineID).HallID).Name;
            string MachineName = _machineApplication.GetDetails(command.MachineID).Name;
            if (command.DateTimeType)
            {
                dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                dateTime = ToPersianDate(DateTime.Now);

            }

            
            using (StreamReader reader = new StreamReader( Path.Combine(_webHostEnvironment.WebRootPath+"/"+_labelTypeApplication.GetDetails(command.LabelType).LabelURL)))
            {
                 fileContent = reader.ReadToEnd();
            }

            while (command.NumberStr<=command.NumberEnd)
            {
                string FinalPrint = fileContent;
                FinalPrint=FinalPrint
                    .Replace("HAMBAFT", command.Interwoven)
                    .Replace("DENIER", command.Den)
                    .Replace("FILAMENT", command.Filament)
                    .Replace("PLY", command.Ply)
                    .Replace("MINGEL", command.Mingel)
                    .Replace("HALL", HallName)
                    .Replace("CODE", command.Personcode)
                    .Replace("MACHINE", MachineName)
                    .Replace("EMPTY1", command.Emptyfield1)
                    .Replace("EMPTY2", command.Emptyfield2)
                    .Replace("EMPTY3", command.Emptyfield3)
                    .Replace("EMPTY4", command.Emptyfield4)
                    .Replace("DATE", dateTime);
                for (byte i = 1;  i<= 3; i++)
                {
                    int count = 0;
                    FinalPrint=Regex.Replace(FinalPrint, "COUNT", m =>
                    {
                        count++;
                        return count == 1 ? command.NumberStr<=command.NumberEnd ? command.NumberStr++.ToString() : "" : m.Value;
                    });
                }
                RawDataPrint.RawPrinterHelper.SendStringToPrinter(GetDefaultPrinterName(), FinalPrint);
                Thread.Sleep(500);
            }

            return RedirectToPage("Index");
        }
    }
}
