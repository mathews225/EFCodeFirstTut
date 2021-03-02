using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTut.Models {
	public class OrderlineController {

		private readonly AppDbContext _context;

		public async Task<IEnumerable<Orderline>> GetAll() {
			return await _context.Orderlines.ToListAsync();
		}

		public async Task<Orderline> GetByPK(int id) {
			return await _context.Orderlines.FindAsync(id);
		}

		public async Task<Orderline> Create(Orderline orderline) {
			if (orderline==null) {
				throw new Exception("ERROR: ORDERLINE CANNOT BE NULL");
			}
			if (orderline.Id!=0) {
				throw new Exception("ERROR: ORDERLINE ID MUST BE 0");
			}
			_context.Add(orderline);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected!=1) {
				throw new Exception("ERROR: ORDERLINE WAS NOT CREATED");
			}
			return orderline;
		}

		public async Task Update(Orderline orderline) {
			if (orderline==null) {
				throw new Exception("ERROR: ORDERLINE CANNOT BE NULL");
			}
			if (orderline.Id != 0) {
				throw new Exception("ERROR: ORDERLINE ID MUST BE GREATER THAN 0");
			}
			_context.Entry(orderline).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: ORDERLINE WAS NOT UPDATED");
			}
			return;
		}

		public async Task<Orderline> Delete(int id) {
			var orderline = await _context.Orderlines.FindAsync(id);
			if (orderline == null) {
				return null;
			}
			_context.Orderlines.Remove(orderline);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: Remove Failed");
			}
			Console.WriteLine($"ORDERLINE DELETED!");
			return orderline;
		}

		public OrderlineController() {
			_context = new AppDbContext();
		}
	}

}
