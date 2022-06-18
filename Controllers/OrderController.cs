﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderItem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OrderItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        List<Cart> ltems = new List<Cart>();
        string apiurl = "http://localhost:21298";

        [HttpGet("{id}")]
        public IActionResult GetCartBy(int id)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseTask = client.GetAsync("MenuItem");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string jsonData = result.Content.ReadAsStringAsync().Result;
                    ltems = JsonConvert.DeserializeObject<List<Cart>>(jsonData);

                    Cart obj1 = ltems.SingleOrDefault(item => item.Id == id);

                    obj1.menuItemId = 1;
                    obj1.userId = 1;

                    return Ok(obj1);
                }
                else
                {
                    return BadRequest();
                }

            };
        }
    }
}
