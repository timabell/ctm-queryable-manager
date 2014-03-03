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
		};

		[Test()]
		public void TestMax ()
		{
			var manager = new Manager {Max=2, repo=mockData.AsQueryable()};
			var results = manager.GetStuff().ToList();
			Assert.AreEqual(2, results.Count);
		}

		[Test()]
		public void TestFilter ()
		{
			var manager = new Manager {Max=2, repo=mockData.AsQueryable()};
			var results = manager.GetStuff().Where(widget => widget.Id !=2).ToList();
			Assert.AreEqual(2, results.Count);
		}
	}

	class Manager{
		public int Max { get; set; }
		public IQueryable<Widget> repo { get; set; }
		public IQueryable<Widget> GetStuff(){
			return repo.Take(Max);
		}
	}

	class Widget{
		public int Id { get; set; }
	}
}

