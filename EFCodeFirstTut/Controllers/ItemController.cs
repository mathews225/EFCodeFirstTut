using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTut.Models {
	public class ItemController {

		private readonly AppDbContext _context;

		public async Task<IEnumerable<Item>> GetAll() {
			return await _context.Items.ToListAsync();
		}

		public async Task<Item> GetByPK(int id) {
			return await _context.Items.FindAsync(id);
		}

		public async Task<Item> Create(Item item) {
			if (item == null) {
				throw new Exception("ERROR: ITEM CANNOT BE NULL");
			}
			if (item.Id != 0) {
				throw new Exception("ERROR: ITEM ID MUST BE 0");
			}
			_context.Add(item);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: ITEM WAS NOT CREATED");
			}
			return item;
		}

		public async Task Update(Item item) {
			if (item == null) {
				throw new Exception("ERROR: ITEM CANNOT BE NULL");
			}
			if (item.Id != 0) {
				throw new Exception("ERROR: ITEM ID MUST BE GREATER THAN 0");
			}
			_context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: ITEM WAS NOT UPDATED");
			}
			return;
		}

		public async Task<Item> Delete(int id) {
			var item = await _context.Items.FindAsync(id);
			if (item == null) {
				return null;
			}
			int count = await _context.Orderlines.Where(s => s.ItemId == item.Id).CountAsync();
			if (count != 0) {
				throw new Exception($"ERROR: Cannot delete major. {count} Student(s) with major");
			}
			_context.Items.Remove(item);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: Remove Failed");
			}
			Console.WriteLine($"ITEM DELETED!");
			return item;
		}

		public ItemController() {
			_context = new AppDbContext();
		}
	}

}
