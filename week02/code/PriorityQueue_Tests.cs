using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue and add three items with different priorities to check if it's using correctly FIFO.
    // Expected Result: [A (Pri:2), B (Pri:5), C (Pri:3)]. 
    // Defect(s) Found: Nothing wrong found.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var expected = "[A (Pri:2), B (Pri:5), C (Pri:3)]";
        Assert.AreEqual(expected, priorityQueue.ToString());

    }

    [TestMethod]
    // Scenario: Create a queue and add four items with different priorities then dequeue to check if the highest priority item is returned.
    // Expected Result: "D"
    // Defect(s) Found: Assert.AreEqual failed. Expected:<D>. Actual:<B>. 
    // So I identified that the loop condition in the Dequeue method is incorrect, causing it to miss the last item in the queue when searching for the highest priority.
    // I fixed it by changing the loop condition from "index < _queue.Count - 1" to "index < _queue.Count".
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 10);

        var dequeuedItem = priorityQueue.Dequeue();
        Assert.AreEqual("D", dequeuedItem);
    }

       [TestMethod]
    // Scenario: Create a queue and add four items with two having the same highest priority then dequeue to check if the first added highest priority item is returned. 
    // Expected Result: "B"
    // Defect(s) Found: Assert.AreEqual failed. Expected:<B>. Actual:<D>. I detected that when two items have the same highest priority, the Dequeue method returns the last one added instead of the first one.
    // I fixed it by changing the comparison operator in the Dequeue method from ">=" to ">" to ensure it only updates the highPriorityIndex when a strictly higher priority is found.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);

        var dequeuedItem = priorityQueue.Dequeue();
        Assert.AreEqual("B", dequeuedItem);
    }

        [TestMethod]
    // Scenario: Create an empty queue and attempt to dequeue an item to check if the appropriate exception is thrown.  
    // Expected Result: "The queue is empty."
    // Defect(s) Found: Nothing wrong found.
        public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown. InvalidOperationException");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        
    }

        [TestMethod]
    // Scenario: Create a queue and add four items with different priorities then dequeue one item and check the remaining items in the queue.
    // Expected Result: "[A (Pri:2), C (Pri:3), D (Pri:5)]"
    // Defect(s) Found:    Assert.AreEqual failed. Expected:<[A (Pri:2), C (Pri:3), D (Pri:5)]>. Actual:<[A (Pri:2), B (Pri:5), C (Pri:3), D (Pri:5)]>.
    // I identified that the Dequeue method was not removing the item with the highest priority from the queue after returning its value.
    // So I fixed it by adding the line "_queue.RemoveAt(highPriorityIndex);" after retrieving the value to ensure the item is removed from the queue.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);
        
        priorityQueue.Dequeue(); 
        var priorityQueueString = priorityQueue.ToString();
        var expected = "[A (Pri:2), C (Pri:3), D (Pri:5)]";
        Assert.AreEqual(expected, priorityQueueString);
    }
}