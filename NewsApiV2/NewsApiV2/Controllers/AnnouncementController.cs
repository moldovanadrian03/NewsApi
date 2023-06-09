﻿using System;
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
        public async Task<IActionResult> GetAnnouncements()
        {
            List<Announcement> announcements = await _announcementCollectionService.GetAll();
            return Ok(announcements);
        }


        /// <summary>
        /// This is an getElementById method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _announcementCollectionService.Get(id);
            return Ok(result);
        }

        /// <summary>
        /// This method takes an ann from the body and return it in the response.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement cannot be null.");
            }

            var result = await _announcementCollectionService.Create(announcement);
            return Ok(announcement);
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
        /// < param name= "announcement" ></ param >
        /// < returns ></ returns >
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Announcement announcement)
        {
            var result = await _announcementCollectionService.Update(announcement.Id, announcement);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _announcementCollectionService.Delete(id);
            return Ok($"Ann: {id} is deleted succesfully.");
        }
    }
}

