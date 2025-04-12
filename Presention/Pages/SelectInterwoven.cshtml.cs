using Application.Contracts.Label;
using Application.Execution.Label;
using Application.Execution.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Pages
{
    public class SelectInterwovenModel : PageModel
    {
        
        private readonly ILabelApplication _labelApplication;

        public SelectInterwovenModel(ILabelApplication labelApplication)
        {
          
            _labelApplication = labelApplication;
        }


        public List<LabelViewModel> LabelView { set; get; }
        public void OnGet(long id)
        {
            LabelView = _labelApplication.Search(new LabelSearchModel
            {
                MachineID = id
            }).Where(x=>x.IsDeleted==false).ToList();
        }
    }
}
