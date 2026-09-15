using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
// Scenario: Add three items to the queue with different priorities.
// Expected Result: Items should be stored in the same order they were added.
// Defect(s) Found:
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual(
            "[First (Pri:1), Second (Pri:5), Third (Pri:3)]",
            priorityQueue.ToString()
        );
    }

    [TestMethod]
// Scenario: Add three items with priorities 1, 5, and 3.
// Expected Result: The highest priority item should be removed first,
// followed by the next highest priority item.
// Defect(s) Found:
public void TestPriorityQueue_2()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("Low", 1);
    priorityQueue.Enqueue("High", 5);
    priorityQueue.Enqueue("Medium", 3);

    var first = priorityQueue.Dequeue();
    var second = priorityQueue.Dequeue();

    Assert.AreEqual("High", first);
    Assert.AreEqual("Medium", second);
}

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Add two items with the same highest priority, followed by
    // an item with a lower priority.
    // Expected Result: The first item with the highest priority should be
    // returned before the second item with the same priority.
    // Defect(s) Found:
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue an item from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with
    // the message "The queue is empty.".
    // Defect(s) Found:
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format(
                    "Unexpected exception of type {0} caught: {1}",
                    e.GetType(),
                    e.Message
                )
            );
        }
    }
}