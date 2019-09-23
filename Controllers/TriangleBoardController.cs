using System;
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

        // GET api/tri
        [HttpGet]
        public IActionResult GetTriangles()
        {
            return Ok(new {triangleBoard = _triangleBoard.Triangles});
        }

        // GET api/tri/A12
        [HttpGet("{triPosition}")]
        public IActionResult GetCoordinates(string triPosition)
        {
            Triangle ret = _triangleBoard.CalculateCoordinates(triPosition);
            if (ret == null)
            {
                return NotFound(new {error = "invalid position"});
            }
            else
            {
                return Ok(new {position = triPosition.ToUpper(), coordinates = ret});
            }
        }

        // GET api/tri/v1x-v1y-v2x-v2y-v3x-v3y
        [HttpGet("{strV1x}-{strV1y}-{strV2x}-{strV2y}-{strV3x}-{strV3y}")]
        public IActionResult GetPosition(string strV1x, string strV1y, string strV2x, string strV2y, string strV3x, string strV3y)
        {
            string errorMessage = "";
            bool didFail = false;

            if (!int.TryParse(strV1x, out int v1x)) {didFail = true; errorMessage += "invalid coordinate v1x ";}
            if (!int.TryParse(strV1y, out int v1y)) {didFail = true; errorMessage += "invalid coordinate v1y ";}
            if (!int.TryParse(strV2x, out int v2x)) {didFail = true; errorMessage += "invalid coordinate v2x ";}
            if (!int.TryParse(strV2y, out int v2y)) {didFail = true; errorMessage += "invalid coordinate v2y ";}
            if (!int.TryParse(strV3x, out int v3x)) {didFail = true; errorMessage += "invalid coordinate v3x ";}
            if (!int.TryParse(strV3y, out int v3y)) {didFail = true; errorMessage += "invalid coordinate v3y";}

            if (didFail)
            {
                return NotFound(new {error = errorMessage});
            }
            else
            {
                string position = _triangleBoard.CalculatePosition(new int[] {v1x, v1y}, new int[] {v2x, v2y}, new int[] {v3x, v3y});
                if (position == null)
                {
                    return NotFound(new {error = "invalid coordinates"});
                }
                else
                {
                return Ok(new { position = position });   
                }
            }
        }
    }
}