using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace justine_webapp.Models.ViewModel
{
    public class TypeViewModel
    {
        public Type Type { get; set; }
        public IEnumerable<item> Items { get; set; }

        public Instrument instrument { get; set; }

        public IEnumerable<SelectListItem> selectListItem(IEnumerable<item>items)
        {
            List<SelectListItem> ItemList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem()
            {
                Text = "Select Item ",
                Value = "0"
            };
            ItemList.Add(sli);
            foreach(item item in Items)
            {
                 sli = new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                ItemList.Add(sli); 
            }
            return ItemList;
        }
    }
}
