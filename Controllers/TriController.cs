using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TriangleBoardApi.Models;
using TriangleBoardApi.Interfaces;
using TriangleApi.Models;

namespace TriangleBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriController : ControllerBase
    {
        public TriController(ITriangleBoard triboard)
        {
            Triboard = triboard;
        }

        public ITriangleBoard Triboard {get; set;}

        [HttpGet]
        public Dictionary<string, Triangle> GetTriangles()
        {
            return Triboard.Triangles;
        }
    }
}