using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Business;

namespace AlphaDictionary.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class DictionaryController : ControllerBase
        {
            [HttpPost("[action]")]
            public ActionResult<string> SearchText([FromBody]DictionaryDTO translateData) //FROM TO: TEXT kachvash tekst, izvejda 
            {
                return Ok(UserInterface.GetWord(translateData.Text, translateData.Lang.ToLower()));
            }

            [HttpPost("[action]")]
            public ActionResult<string> SearchImage([FromBody]DictionaryDTO translateData) //FROM TO: IMAGE
            {
                string reqimagetext = OCR.OCR.GetText(translateData.Image);
                return Ok(UserInterface.GetWord(reqimagetext, translateData.Lang.ToLower()));
            }
        }
}