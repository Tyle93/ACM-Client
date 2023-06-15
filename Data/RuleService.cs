using ACM.ACM_Models;
using ACM.Context;


namespace MauiApp1.Data
{
	public static class RuleService
	{
		private static ACMContext _context;
		public static List<CouponRule> rules { get; private set; }
		public static CouponRule currentRule { get; private set; }
		public static List<ACM.ACM_Models.CouponItem> items { get; private set; } = new List<ACM.ACM_Models.CouponItem>();
		public static List<CouponDailyAvailability> schedule { get; private set; } = new List<ACM.ACM_Models.CouponDailyAvailability>();
        static RuleService()
		{
			_context = new ACMContext();
			LoadRules();
			LoadInitialRule();
			LoadSchedule();
        }
		private static void LoadSchedule()
		{
			schedule = _context.CouponDailyAvailabilities.Where((sched) => sched.CouponRuleId == currentRule.Id).ToList();
		}
		private static void LoadInitialRule()
		{
			currentRule = rules.First();
			items = GetCouponItems(currentRule.Id);
		}
		public static void LoadRule(string ruleId)
		{
			if(currentRule.Id is not null)
			{
                _context.Entry(currentRule).Reload();
            }
			currentRule = (from rule in rules
						  where rule.Id == ruleId
						  select rule).First();
			items = GetCouponItems(currentRule.Id);
			LoadSchedule();
		}
		private static void LoadRules()
		{
            rules = _context.CouponRules.ToList();
            if (!rules.Any())
            {
                var id = Guid.NewGuid().ToString();
                var rule = new CouponRule()
                {
                    Id = id,
                    Name = $"New Rule: {id}",
                    IsActive = BitConverter.GetBytes(true),
                    Notes = "",
                    ReceiptName = "",
                    IsDiscountExclusive = BitConverter.GetBytes(true),
                    MaxApplications = -1,
                    StartDate = "1970-01-01",
                    EndDate = "9999-12-31"
                };
                _context.CouponRules.Add(rule);
				rules.Add(rule);
				_context.SaveChanges();
            }
            rules.Sort((r1, r2) => String.Compare(r1.Name,r2.Name));
        }
		public static void CreateNewCouponRule()
		{
			var id = Guid.NewGuid().ToString();
			_context.CouponRules.Add(new CouponRule()
			{
				Id = id,
				Name = $"New Rule: {id}",
				IsActive = BitConverter.GetBytes(true),
				Notes = "",
				ReceiptName = "",
				IsDiscountExclusive = BitConverter.GetBytes(true),
				MaxApplications = -1,
				StartDate = "1970-01-01",
				EndDate = "9999-12-31"
			});
			_context.SaveChanges();
			ReloadRules();
			LoadRule(id);
		}
        public static void CreateNewCouponRuleItem()
        {
			CouponItem couponItem = new CouponItem()
			{
				Id = Guid.NewGuid().ToString(),
				CouponRuleId = currentRule.Id,
				IsRequired = BitConverter.GetBytes(true),
				Operation = "none",
				ItemName = FutureDbService._departmentItems.First().Value.First().ItemName
            }; 
            _context.CouponItems.Add(couponItem);
            _context.SaveChanges();
			items = GetCouponItems(currentRule.Id);
        }

		public static void CreateNewCouponScheduleItem()
		{
			CouponDailyAvailability couponDailyAvailability = new CouponDailyAvailability()
			{
				Id = Guid.NewGuid().ToString(),
				StartHour = -1,
				StartMinute = -1,
				EndHour = -1,
				EndMinute = -1,
				DayIndex = -1,
				CouponRuleId = currentRule.Id,
				IsActive = BitConverter.GetBytes(true),
			};
			_context.CouponDailyAvailabilities.Add(couponDailyAvailability);
			_context.SaveChanges();
			schedule = _context.CouponDailyAvailabilities.Where((sched) => sched.CouponRuleId == currentRule.Id).ToList();
		}
		public static void RemoveExistingCouponRuleItem(CouponItem? ruleItem)
		{
			if(ruleItem is not null)
			{
                _context.CouponItems.Remove(ruleItem);
				_context.SaveChanges();
				items = GetCouponItems(currentRule.Id);
            }
		}
		public static void RemoveExistingCouponScheduleItem(CouponDailyAvailability sched)
		{
			if(sched is not null)
			{
				_context.CouponDailyAvailabilities.Remove(sched);
				_context.SaveChanges(true);
                schedule = _context.CouponDailyAvailabilities.Where((sched) => sched.CouponRuleId == currentRule.Id).ToList();
            }
		}

        public static void ReloadRules()
		{
			LoadRules();
		}
		public static List<CouponItem>? GetCouponItems(string? ruleId) 
		{
			if (ruleId is null) return null;
			return _context.CouponItems.Where((item) => item.CouponRuleId == ruleId).ToList();
		}
		public static void SaveRuleChanges()
		{
			_context.SaveChanges();
		}
		public static void RemoveRule()
		{
			_context.CouponRules.Remove(currentRule);
			foreach (var item in items)
			{
				_context.CouponItems.Remove(item);
			}
			_context.SaveChanges();
			ReloadRules();
			LoadRule(rules.First().Id);
		}

	}
}
