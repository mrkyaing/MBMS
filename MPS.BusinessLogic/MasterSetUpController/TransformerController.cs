using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class TransformerController : ITransformer
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteTransformer(Transformer tf)
        {
            Transformer transformer = mBMSEntities.Transformers.Where(x => x.TransformerID == tf.TransformerID).SingleOrDefault();
            transformer.Active = tf.Active;
            transformer.DeletedDate = DateTime.Now;
            transformer.DeletedUserID = tf.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(Transformer tf)
        {
            mBMSEntities.Transformers.Add(tf);
            mBMSEntities.SaveChanges();
        }

        public void UpdateTransformer(Transformer tf)
        {
            Transformer transformer = mBMSEntities.Transformers.Where(x => x.TransformerID == tf.TransformerID).SingleOrDefault();
            transformer.TransformerName = tf.TransformerName;
            transformer.GPSX = tf.GPSX;
            transformer.GPSY = tf.GPSY;
            transformer.Address = tf.Address;
            transformer.QuarterID = tf.QuarterID;
            transformer.Model = tf.Model;
            transformer.Status = tf.Status;
            transformer.UpdatedUserID = tf.UpdatedUserID;
            transformer.UpdateDate =tf.UpdateDate;
            mBMSEntities.Transformers.AddOrUpdate(transformer); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
