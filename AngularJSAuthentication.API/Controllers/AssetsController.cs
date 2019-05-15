﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularJSAuthentication.API;
using AngularJSAuthentication.API.Models;

namespace AngularJSAuthentication.API.Controllers
{
    [RoutePrefix("api/Assets")]
    public class AssetsController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Assets
        public List<AssetModel> GetAssets()
        {
            List<AssetModel> ListAssetModel = new List<AssetModel>();

            List<Asset> listOfAsset = db.Assets.ToList();

            foreach (Asset asset in listOfAsset)
            {
                AssetModel AssetModel = new AssetModel();
                AssetModel.name = asset.Name;
                AssetModel.address = asset.Address;
                AssetModel.contact = asset.Contact;
                AssetModel.assetID = asset.AssetID;
                //AssetModel.projectID = asset.ProjectID;

                ListAssetModel.Add(AssetModel);
            }


            return ListAssetModel;
          
        }

        // GET: api/Assets/5
        [ResponseType(typeof(Asset))]
        public List<AssetModel> GetAsset(string userName)
        {

            var userID = db.Users.FirstOrDefault(x => x.UserName == userName).Id;
            List<AssetModel> ListAssetModel = new List<AssetModel>();

            //List<Asset> listOfAsset = db.Assets.Where(x => x.ProjectID == id).ToList();

            //List<Asset> listOfAsset = db.Assets.ToList();
            List<Asset> listOfAsset = db.Assets.Where(x => x.UserId == userID).ToList();

            foreach (Asset asset in listOfAsset)
            {
                AssetModel AssetModel = new AssetModel();
                AssetModel.name = asset.Name;
                AssetModel.address = asset.Address;
                AssetModel.contact = asset.Contact;
                AssetModel.assetID = asset.AssetID;
                //AssetModel.projectID = asset.ProjectID;

                ListAssetModel.Add(AssetModel);
            }


            return ListAssetModel;              
        }


        [HttpGet]
        [Route("GetAssetByProjectID")]
        [ActionName("GetAssetByProjectID")]
        public List<AssetModel> GetAssetByProjectID(string userName)
        {

            var userID = db.Users.FirstOrDefault(x => x.UserName == userName).Id;
            List<AssetModel> ListAssetModel = new List<AssetModel>();

            //List<Asset> listOfAsset = db.Assets.Where(x => x.ProjectID == id).ToList();

            //List<Asset> listOfAsset = db.Assets.ToList();
            List<Asset> listOfAsset = db.Assets.Where(x => x.UserId == userID).ToList();


            foreach (Asset asset in listOfAsset)
            {
                AssetModel AssetModel = new AssetModel();
                AssetModel.name = asset.Name;
                AssetModel.address = asset.Address;
                AssetModel.contact = asset.Contact;
                AssetModel.assetID = asset.AssetID;
                //AssetModel.projectID = asset.ProjectID;

                ListAssetModel.Add(AssetModel);
            }


            return ListAssetModel;
        }    
        



        // PUT: api/Assets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsset(Asset asset)
        {
            var id = asset.AssetID;

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            if (id != asset.AssetID)
            {
                return BadRequest();
            }

            db.Entry(asset).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Assets
        [ResponseType(typeof(Asset))]
        public IHttpActionResult PostAsset(assetPostModel assetPostModel)
        {

            var userID = db.Users.FirstOrDefault(x => x.UserName == assetPostModel.UserName).Id;

            assetPostModel.Asset.UserId = userID;

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            db.Assets.Add(assetPostModel.Asset);
            db.SaveChanges();

            var projectID = assetPostModel.projectID;

            AssetsProject AssetsProject = new AssetsProject();
            AssetsProject.projectID = projectID;
            AssetsProject.assetID = assetPostModel.Asset.AssetID;

            db.AssetsProjects.Add(AssetsProject);
            db.SaveChanges();

            return Ok(assetPostModel.Asset);
        }

        // DELETE: api/Assets/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult DeleteAsset(int id)
        {
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return NotFound();
            }

            db.Assets.Remove(asset);
            db.SaveChanges();

            return Ok(asset);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetExists(int id)
        {
            return db.Assets.Count(e => e.AssetID == id) > 0;
        }
    }
}