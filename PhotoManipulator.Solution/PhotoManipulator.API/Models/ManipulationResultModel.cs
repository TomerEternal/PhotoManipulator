using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoManipulator.API.Models
{
    public class ManipulationResultModel
    {
        public ImageModel Image { get; set; }
        public class ImageModel
        {
            public string ContentType { get; private set; }
            public byte[] Content { get; private set; }

            public ImageModel(string contentType, byte[] content)
            {
                ContentType = contentType;
                Content = content;
            }
        }
    }
}