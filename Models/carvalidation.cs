using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace carrental1.Models
{
    [MetadataType(typeof(carregMetaData))]
    public partial class carreg
    {

        public class carregMetaData
        {
           
            [DisplayName("CarNo")]
            
            public string carno { get; set; }
            [DisplayName("Brand")]
            public string make { get; set; }
            [DisplayName("Model")]
            public string model { get; set; }
            [DisplayName("Available")]
            public string available { get; set; }
        }
    }
}