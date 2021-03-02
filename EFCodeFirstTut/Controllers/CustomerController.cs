using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTut.Models {
	public class CustomerController {

		private readonly AppDbContext _context;

		public async Task<IEnumerable<Customer>> GetAll() {
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> GetByPK(int id) {
			return await _context.Customers.FindAsync(id);
		}

		public async Task<Customer> Create(Customer customer) {
			if (customer == null) {
				throw new Exception("ERROR: CUSTOMER CANNOT BE NULL");
			}
			if (customer.Id != 0) {
				throw new Exception("ERROR: CUSTOMER ID MUST BE 0");
			}
			_context.Add(customer);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: CUSTOMER WAS NOT CREATED");
			}
			return customer;
		}

		public async Task Update(Customer customer) {
			if (customer == null) {
				throw new Exception("ERROR: CUSTOMER CANNOT BE NULL");
			}
			if (customer.Id != 0) {
				throw new Exception("ERROR: CUSTOMER ID MUST BE GREATER THAN 0");
			}
			_context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: CUSTOMER WAS NOT UPDATED");
			}
			return;
		}

		public async Task<Customer> Delete(int id) {
			var customer = await _context.Customers.FindAsync(id);
			if (customer == null) {
				return null;
			}
			int count = await _context.Orders.Where(s => s.CustomerId == customer.Id).CountAsync();
			if (count != 0) {
				throw new Exception($"ERROR: Cannot delete major. {count} Student(s) with major");
			}
			_context.Customers.Remove(customer);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) {
				throw new Exception("ERROR: Remove Failed");
			}
			Console.WriteLine($"CUSTOMER DELETED!");
			return customer;
		}

		public CustomerController() {
			_context = new AppDbContext();
		}
	}

}
