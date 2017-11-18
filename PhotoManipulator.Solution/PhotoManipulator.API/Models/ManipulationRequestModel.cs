using MultipartDataMediaFormatter.Infrastructure;
using PhotoManipulator.BLL.PixelManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoManipulator.API.Models
{
    //Currently unused.
    public class ManipulationRequestModel
    {
        [Required]
        public string Effect { get; set; }
        [Required]
        public HttpFile Image { get; set; }
        public HttpFile Image2 { get; set; }
        public PixelManager.ManipulationEffect GetEffect()
        {
            PixelManager.ManipulationEffect effectEnum;
            Enum.TryParse<PixelManager.ManipulationEffect>(Effect, out effectEnum);
            return effectEnum;
        }
    }
}