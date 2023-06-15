using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Context;
using ACM.Models;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace MauiApp1.Data
{
	public static class FutureDbService
	{
		public static FPOSContext _context { get; private set; }
		public static List<Item> _items { get; private set; }
		public static List<Department> _departments { get; private set; }
		public static Dictionary<string, List<Item>> _departmentItems { get; private set; }
		static FutureDbService()
		{
			_context = new FPOSContext();
			GetItemList();
			GetDepartments();
			SplitItemsByDepartment();
		}
		private static void SplitItemsByDepartment()
		{
			List<Department> emptyDepartments = new List<Department>();
            _departmentItems = new Dictionary<string, List<Item>>();
            foreach (var dep in _departments)
			{ 
				var depItems = _items.Where((item) => item.Department == dep.DepartmentName).ToList();
				if(depItems is null || !depItems.Any())
				{
					emptyDepartments.Add(dep);
				}
				else
				{
                    _departmentItems[dep.DepartmentName] = depItems;
                }
			}
			foreach(var empty in emptyDepartments)
			{
				_departments.Remove(empty);
			}
		}
		private static void GetItemList()
		{
            _items = _context.Items.ToList();
			_items.Sort((a, b) => String.Compare(a.ItemName, b.ItemName));
        }		
		private static void GetDepartments()
		{
			_departments = _context.Departments.ToList();
		}
		public static List<Item>? GetRuleItems(List<ACM.ACM_Models.CouponItem> items)
		{
			if (!items.Any()) return null;
			var retItems = _context.Items.Join(items, saleItem => saleItem.ItemName, couponItem => couponItem.ItemName, (saleItem, couponItem) => saleItem);
			if (!retItems.Any()) return null;
			return retItems.ToList();
		}
	}
}
