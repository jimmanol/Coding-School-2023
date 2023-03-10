using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Repositories {
    public class TransactionLineRepo: IEntityRepo<TransactionLine>{
        public void Add(TransactionLine entity) {
            using var context = new AppDbContext();
            if (!EntityExist(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public void Delete(Guid id) {
            using var context = new AppDbContext();
            var TransactionLineDb = context.TransactionLines.Where(transactionLine => transactionLine.ID == id).SingleOrDefault();
            if (TransactionLineDb is null)
                return;
            context.Remove(TransactionLineDb);
            context.SaveChanges();
        }

        public bool EntityExist(TransactionLine entity) {
            using var context = new AppDbContext();
            var TransactionLineDb = context.TransactionLines
                .Where(transactionLine => transactionLine.ServiceTaskID == entity.ServiceTaskID
                && transactionLine.TransactionID == entity.TransactionID
                && transactionLine.Hours == entity.Hours
                && transactionLine.EngineerID == entity.EngineerID)
                .SingleOrDefault();
            if (TransactionLineDb is null) {
                var TransactionLine1Db = context.TransactionLines
                .Where(transactionLine => transactionLine.ID == entity.ID).SingleOrDefault();
                if (TransactionLine1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }
        public IList<TransactionLine> GetAll() {
            using var context = new AppDbContext();
            return context.TransactionLines.Include(transactionLine => transactionLine.Transaction).ToList();
        }

        public TransactionLine? GetById(Guid id) {
            using var context = new AppDbContext();
            return context.TransactionLines.Where(transactionLine => transactionLine.ID == id).SingleOrDefault();
        }

        public void Update(Guid id, TransactionLine entity) {
            using var context = new AppDbContext();
            var TransactionLineDb = context.TransactionLines.Where(transactionLine => transactionLine.ID == id).SingleOrDefault();
            if (TransactionLineDb is null)
                return;
            TransactionLineDb.Price = entity.Price;
            TransactionLineDb.PricePerHour = entity.PricePerHour;
            TransactionLineDb.Hours = entity.Hours;
            TransactionLineDb.ServiceTaskID = entity.ServiceTaskID;

            context.SaveChanges();
        }
    }
}