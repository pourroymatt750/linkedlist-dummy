using System;
using System.Linq;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val)
    {
        this.val = val;
    }
}

public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null) return head;

        //Store unique numbers
        HashSet<int> unique = new HashSet<int>();

        // Create a dummy node to simplify handling of the head
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode curr = dummy; //Reference to the head of modified list

        while (curr.next != null && curr.next.next != null)
        {
            if (curr.next.val == curr.next.next.val)
            {
                unique.Add(curr.next.val);
            }

            if (unique.Contains(curr.next.val))
            {
                curr.next = curr.next.next;

                if (unique.Contains(curr.next.val) && curr.next.next == null)
                {
                    curr.next = null;
                }
            }
            else
            {
                curr = curr.next;
            } 
        }

        return dummy.next;
    }
}