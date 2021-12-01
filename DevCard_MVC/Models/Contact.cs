using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevCard_MVC.Models {
    public class Contact {
        [Required(ErrorMessage ="این فیلد اجباری است")]
        [MinLength(3, ErrorMessage ="حداقل طول پیام 3 کاراکتر است")]
        [MaxLength(100, ErrorMessage ="حداکثر طول پیام 100 کاراکتر است")]
        public string Name {
            get; set;
        }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [EmailAddress(ErrorMessage ="مقدار وارد شده ایمیل صحیح نیس")]
        public string Email {
            get; set;
        }
        public string Message {
            get; set;
        }
        public string Service {
            get; set;
        }
    }
}
