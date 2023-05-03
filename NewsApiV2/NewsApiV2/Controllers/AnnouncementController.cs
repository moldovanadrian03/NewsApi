using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApiV2.Controllers.Models;
using NewsApiV2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsApiV2
{
    [ApiController]
    [Route("api/[controller]")]
    // routa va fii localhost:port/api/Announcement
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }


        /// <summary>
        /// This method returns all Announcements.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAnnouncements()
        {
            List<Announcement> announcements = _announcementCollectionService.GetAll();
            return Ok(announcements);
        }


        /// <summary>
        /// This is an getElementById method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Announcement announcement = _announcements[Guid2Int(id)];
            return Ok(announcement);
        }

        /// <summary>
        /// This method takes an ann from the body and return it in the response.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement cannot be null.");
            }
            _announcements.Add(announcement);
            return Ok(_announcements);
        }

       ///// <summary>
       ///// This method update an existing announcement.
       ///// </summary>
       ///// <param name="id"></param>
       ///// <param name="announcement"></param>
       ///// <returns></returns>
       // [HttpPut]
       // public IActionResult Update([FromRoute] Guid id, [FromBody] Announcement announcement)
       // {
       //     bool exist = false;
       //     if(announcement == null)
       //     {
       //         return BadRequest("Announcement cannot be null.");
       //     }
       //     foreach(Announcement currAnn in _announcements)
       //     {   //TODO remake this
       //         if (currAnn.Id == id)
       //         {
       //             exist = true;
       //             _announcements.Remove(currAnn);
       //             _announcements.Add(announcement);
       //             break;
       //         }
       //     }
       //     if (exist) { return Ok($"Ann: {announcement} is updated succesfully."); }
       //     return NotFound();
       // }

        /// <summary>
        /// This method update an existing announcement.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="announcement"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update2([FromBody] Announcement announcement)
        {
            Announcement annToUpdate = _announcements.FirstOrDefault(item => item.Id == announcement.Id);
            if(annToUpdate == null)
            {
                _announcements.Add(announcement);
            }
            else
            {
                annToUpdate.Title = announcement.Title;
                annToUpdate.Author = announcement.Author;
                annToUpdate.CategoryId = announcement.Author;
                annToUpdate.Description = announcement.Description;
            }
            return Ok(announcement);
        }

        ///// <summary>
        ///// This method delete an announcement by id.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //public IActionResult Delete([FromRoute] Guid id)
        //{
        //    bool exist = false;
        //    foreach (Announcement currAnn in _announcements)
        //    {
        //        if (currAnn.Id == id)
        //        {
        //            exist = true;
        //            _announcements.Remove(currAnn);
        //            break;
        //        }
        //    }
        //    if (exist) { return Ok($"Ann: {id} is deleted succesfully."); }
        //    return NotFound();
        //}
        /// <summary>
        /// This method delete an announcement by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete2([FromRoute] Guid id)
        {
            //sterge toate ann care au id-ul egal cu id-ul din param adica unul singur
            int deletedElements = _announcements.RemoveAll(item => item.Id == id);
            if (deletedElements == 0)
            {
                return NotFound("Ann cannot be deleted.");
            }
            return Ok($"Ann: {id} is deleted succesfully.");
        }

        /// <summary>
        /// This method convert and GUID value to INT
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Guid2Int(Guid value)
        {
            byte[] b = value.ToByteArray();
            int bint = BitConverter.ToInt32(b, 0);
            return bint;
        }
    }
}

