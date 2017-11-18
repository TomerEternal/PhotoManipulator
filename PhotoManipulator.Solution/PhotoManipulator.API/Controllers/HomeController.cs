using MultipartDataMediaFormatter.Infrastructure;
using PhotoManipulator.API.Models;
using PhotoManipulator.BLL.PixelManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using static PhotoManipulator.API.Models.ManipulationResultModel;

namespace PhotoManipulator.API.Controllers
{
    [EnableCors("http://localhost:3000", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        // GET: api/Home
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET: api/Home/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        public IHttpActionResult Post(ManipulationRequestModel value)
        {
            Bitmap image = null;
            try
            {
                using (MemoryStream ms = new MemoryStream(value.Image.Buffer))
                    image = new Bitmap(ms, false);
                PixelManager.Manipulate(image,value.GetEffect());
                byte[] manipulatedImageByteArr;
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Png);
                    manipulatedImageByteArr = ms.ToArray();
                }
                return Ok(new ManipulationResultModel
                {
                    Image = new ImageModel("image/png",
                    manipulatedImageByteArr)
                });
            }
            finally
            {
                image?.Dispose();
            }
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
        }

        /* Irrelevant yet cool to know
        * this will return the image itself
        */
        //[HttpGet]
        //[Route(@"api/home/image")]
        //public HttpResponseMessage GetImageAsHttpResponseMessage()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    Image reversedImage = PixelManager.(new Bitmap(Image.FromFile($@"C:\Users\Tomer Hirshfeld\Source\Repos\PhotoManipulator\PhotoManipulator.Solution\PhotoManipulator.BLL.Test\MockImages\Car.jpeg")));
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        reversedImage.Save(ms, ImageFormat.Png);
        //        response.Content = new ByteArrayContent(ms.ToArray());
        //        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
        //        return response;
        //    }
        //}
    }
}
