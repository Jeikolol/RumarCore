using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Models
{
    public class NewOrEditItemViewModel
    {
        public NewOrEditItemViewModel(string controllerName, object formViewModel, NewOrEditViewModelType type)
        {
            FormViewModel = formViewModel;
            Type = type;
            Form = BuildFormUri(controllerName);
        }

        private string BuildFormUri(string controllerName)
        {
            string result;

            switch (Type)
            {
                case NewOrEditViewModelType.New:
                    result = $"../{controllerName}/Views/Create";
                    break;
                case NewOrEditViewModelType.Edit:
                    result = $"../{controllerName}/Views/Edit";
                    break;
                case NewOrEditViewModelType.Custom:
                    result = $"../{controllerName}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Icon { get; set; }

        public string Form { get; private set; }
        public string FormId { get; set; }
        public string FormAction { get; set; }
        public FormMethod FormMethod { get; set; } = FormMethod.Post;
        public object FormViewModel { get; private set; }
        public bool IsLargeModal { get; set; }
        public bool Scrollable { get; set; }
        public bool UseAntiForgeryToken { get; set; } = true;
        public NewOrEditViewModelType Type { get; private set; }
        public string modalType { get; set; }
    }

    public enum NewOrEditViewModelType
    {
        New,
        Edit,
        Custom
    }
}
