using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace justine_webapp.Models
{
    public class InstrumentViewModel
    {
         public Instrument instrument{ get; set; }

        public IEnumerable<item> Items { get; set; }

        public IEnumerable<Type> types { get; set; }


         public IEnumerable<SelectListItem> selectListItem(IEnumerable<item>items)
        {
            List<SelectListItem> ItemList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem()
            {
                Text = "Select Item ",
                Value = "0"
            };
            ItemList.Add(sli);
            foreach(item item in items)
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
        public IEnumerable<SelectListItem> selectListType(IEnumerable<Type>types)
        {
            List<SelectListItem> TypeList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem()
            {
                Text = "Select Item ",
                Value = "0"
            };
            TypeList.Add(sli);
            foreach(Type type in types)
            {
                 sli = new SelectListItem()
                {
                    Text = type.Name,
                    Value = type.id.ToString()
                };
                TypeList.Add(sli); 
            }
            return TypeList;
        }
        
    }

}