﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Azure.Storage.Blobs;
using RMotownFestival.Api.Common;

namespace RMotownFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        public BlobUtility BlobUtility { get; }

        public PicturesController(BlobUtility blobUtility)
        {
            BlobUtility = blobUtility;
        }

        [HttpGet]
        public string[] GetAllPictureUrls()
        {
            BlobContainerClient container = BlobUtility.GetThumbsContainer();

            return container.GetBlobs().Select(blob => BlobUtility.GetSasUri(container, blob.Name)).ToArray();
        }

        [HttpPost]
        public void PostPicture(IFormFile file)
        {
            BlobContainerClient container = BlobUtility.GetPicturesContainer();
            container.UploadBlob(file.FileName, file.OpenReadStream());
        }
    }
}
