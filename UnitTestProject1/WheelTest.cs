using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wheel;

namespace UnitTestProject1
{
	[TestClass]
	public class WheelTest
	{
		private static Wheel<int> Setup()
		{
			var wheel = new Wheel<int>();
			wheel.Push(1);
			wheel.Push(2);
			wheel.Push(3);
			return wheel;
		}

		[TestMethod]
		public void TestCount()
		{
			var wheel = Setup();
			Assert.AreEqual(3, wheel.Count);
		}

		[TestMethod]
		public void TestPeek()
		{
			var wheel = Setup();
			Assert.AreEqual(3, wheel.Peek());
		}

		[TestMethod]
		public void TestPop()
		{
			var wheel = Setup();
			Assert.AreEqual(3, wheel.Pop());
			Assert.AreEqual(2, wheel.Pop());
		}

		[TestMethod]
		public void TestRotate()
		{
			var wheel = Setup();
			wheel.Rotate(1);
			Assert.AreEqual(1, wheel.Pop());
			Assert.AreEqual(3, wheel.Pop());
		}

		[TestMethod]
		public void TestRotate2()
		{
			var wheel = Setup();
			wheel.Rotate(4);
			Assert.AreEqual(1, wheel.Pop());
			Assert.AreEqual(3, wheel.Pop());
		}

		[TestMethod]
		public void TestRotate3()
		{
			var wheel = Setup();
			wheel.Rotate(7);
			Assert.AreEqual(1, wheel.Pop());
			Assert.AreEqual(3, wheel.Pop());
		}

		[TestMethod]
		public void TestRotate4()
		{
			var wheel = Setup();
			wheel.Rotate(2);
			Assert.AreEqual(2, wheel.Pop());
			Assert.AreEqual(1, wheel.Pop());
		}

		[TestMethod]
		public void TestRotate5()
		{
			var wheel = Setup();
			wheel.Rotate(3);
			Assert.AreEqual(3, wheel.Pop());
			Assert.AreEqual(2, wheel.Pop());
		}
	}
}
