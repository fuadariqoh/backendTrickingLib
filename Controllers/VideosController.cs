using System.Collections;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Microsoft.Net.Http.Headers;

namespace TrickingLibrary.Controllers
{


        [Route("api/videos")]    
        public class VideosController : ControllerBase
         {


            private readonly IWebHostEnvironment _env;

               public VideosController(IWebHostEnvironment env)
               {
                    _env = env;    
               }

            [HttpGet("{video}")]
            public IActionResult GetVideo(string video)
            {
            var savePath = Path.Combine(_env.WebRootPath, video);
            Console.WriteLine(savePath);
            return new FileStreamResult(new FileStream(savePath, FileMode.Open, FileAccess.Read),"video/*");
            }

               [DisableRequestSizeLimit]
               [HttpPost]
                public async Task<IActionResult> UploadVideo(IFormFile video)
               {
                System.Console.WriteLine("masuk upload video");
                var mime=video.FileName.Split('.').Last();
                var fileName= string.Concat(Path.GetRandomFileName(),".",mime);
                var savePath= Path.Combine(_env.WebRootPath,fileName) ; 
                System.Console.WriteLine(savePath);

                 using (var fileStream= new FileStream(savePath,FileMode.Create,FileAccess.Write))
                {

                  await video.CopyToAsync(fileStream);
                  
                } 



                   return Ok(fileName);
                   

               }

            }


}