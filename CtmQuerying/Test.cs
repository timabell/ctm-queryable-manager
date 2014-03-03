using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CtmQuerying
{
	[TestFixture()]
	public class Test
	{
		List<Widget> mockData = new List<Widget>{
			new Widget{ Id=1},
			new Widget{ Id=2},
			new Widget{ Id=3},
			new Widget{ Id=4},
		};

		[Test()]
		public void TestMax ()
		{
			var manager = new Manager {repo=mockData.AsQueryable()};
			// pagination (take) moved out of manager class as can be done entirely by client with IQueryable
			var results = manager.GetStuff().Take(2).ToList();
			Assert.AreEqual(2, results.Count);
		}

		[Test()]
		public void TestFilter ()
		{
			var manager = new Manager {repo=mockData.AsQueryable()};
			var results = manager.GetStuff().Where(widget => widget.Id !=2).Take (2).ToList();
			Assert.AreEqual(2, results.Count);
		}
	}

	class Manager{
		public IQueryable<Widget> repo { get; set; }
		public IQueryable<Widget> GetStuff(){
			return repo;
		}
	}

	class Widget{
		public int Id { get; set; }
	}
}

