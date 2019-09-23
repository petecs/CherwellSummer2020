using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TriangleBoardApi.Models;
using TriangleBoardApi.Interfaces;
using TriangleApi.Models;

namespace TriangleBoardApi.Controllers
{
    [Route("api/tri")]
    [ApiController]
    public class TriangleBoardController : ControllerBase
    {
        private ITriangleBoard _triangleBoard;
        public TriangleBoardController(ITriangleBoard triangleBoard)
        {
            _triangleBoard = triangleBoard;
        }

        [HttpGet]
        public Dictionary<string, Triangle> GetTriangles()
        {
            return _triangleBoard.Triangles;
        }

        // [Route("{name}")]
        // public int GetCoordinates(string triangle)
        // {
        //     return 0;
        // }
    }
}