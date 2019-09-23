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
        public Dictionary<string, Triangle> GetTriangles()
        {
            return _triangleBoard.Triangles;
        }

        // GET api/tri/A12
        [HttpGet("{triPosition}")]
        public Triangle GetCoordinates(string triPosition)
        {
            return _triangleBoard.CalculateCoordinates(triPosition);
        }

        // GET api/tri/v1x,v1y,v2x,v2y,v3x,v3y
        [HttpGet("{strV1x},{strV1y},{strV2x},{strV2y},{strV3x},{strV3y}")]
        public string GetPosition(string strV1x, string strV1y, string strV2x, string strV2y, string strV3x, string strV3y)
        {
            string errorMessage = "";
            bool didFail = false;

            if (Int32.TryParse(strV1x, out int v1x)) {} else {didFail = true; errorMessage += "invalid coordinate v1x\n";}
            if (Int32.TryParse(strV1y, out int v1y)) {} else {didFail = true; errorMessage += "invalid coordinate v1y\n";}
            if (Int32.TryParse(strV2x, out int v2x)) {} else {didFail = true; errorMessage += "invalid coordinate v2x\n";}
            if (Int32.TryParse(strV2y, out int v2y)) {} else {didFail = true; errorMessage += "invalid coordinate v2y\n";}
            if (Int32.TryParse(strV3x, out int v3x)) {} else {didFail = true; errorMessage += "invalid coordinate v3x\n";}
            if (Int32.TryParse(strV3y, out int v3y)) {} else {didFail = true; errorMessage += "invalid coordinate v3y\n";}

            if (didFail)
            {
                return errorMessage;
            }
            else
            {
                return _triangleBoard.CalculatePosition(new int[] {v1x, v1y}, new int[] {v2x, v2y}, new int[] {v3x, v3y});
            }
        }

        // [Route("{name}")]
        // public int GetCoordinates(string triangle)
        // {
        //     return 0;
        // }
    }
}