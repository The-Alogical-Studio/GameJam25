using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
	[SerializeField] private GameObject[] items;
	[SerializeField] private GameObject[] itemsIn;
	[SerializeField] private GameObject[] slots;
	[SerializeField] private int HotSlot;
	[SerializeField] private InvaTable inv;
	[SerializeField] private MinHeap que;

	void Awake(){

		que = new MinHeap(10);
			
		for(int i = 0; i < slots.Length; i++){
			que.Insert(i);
		}
	}

	public void AddItem(int id){
		if(inv.im[id].count == 0){
			inv.im[id].slot = slots[que.ExtractMin()];
			GameObject gm = Instantiate(itemsIn[id], inv.im[id].slot.transform);
			gm.name = $"{id}";
		}
		inv.im[id].count += 1;
	}

	public void DropItem(int slot){
		if(slots[slot].transform.childCount == 0) return;
		int id = int.Parse(slots[slot].transform.GetChild(0).name);
		Instantiate(items[id], transform.position + transform.forward * 2, Quaternion.identity);
		inv.im[id].count -= 1;
		if(inv.im[id].count == 0){
			Destroy(slots[slot].transform.GetChild(0).gameObject);
			inv.im[id].slot = null;
			que.Insert(slot);
		}
	}

	void Update(){
		for(int i = 0; i < slots.Length; i++){
			if(Input.GetKeyDown(KeyCode.Alpha1 + i)){
				HotSlot = i;
				return;
			}
		}

		if(Input.GetKeyDown(KeyCode.Q)){
			DropItem(HotSlot);
		}
	}


}

[Serializable]
public class Item {
	public GameObject slot;
	public int count;
}

[Serializable]
public class InvaTable {
	public Item[] im;
}


/*
[Serializable]
public class HQueueNode {
	public int value;
	public HQueueNode next;
}


[Serializable]
public class HQueue {
	public HQueueNode first;
	public HQueueNode last;

	public void push(int i){
		HQueueNode nLast = new HQueueNode();
		nLast.value = i;

		if(first == null){
			first = nLast;
			last = nLast;
			return;
		}

		last.next = nLast;
		last = nLast;
	}

	public int pop(){
		int rV = first.value;
		first = first.next;
		return rV;
	}
}
*/

public class MinHeap
{
	private int[] heap;
	private int size;
	private int capacity;

	public MinHeap(int capacity)
	{
		this.capacity = capacity;
		heap = new int[capacity];
		size = 0;
	}

	private int Parent(int i)
	{
		return (i - 1) / 2;
	}

	private int LeftChild(int i)
	{
		return 2 * i + 1;
	}

	private int RightChild(int i)
	{
		return 2 * i + 2;
	}

	private void Swap(int i, int j)
	{
		int temp = heap[i];
		heap[i] = heap[j];
		heap[j] = temp;
	}

	private void HeapifyUp(int i)
	{
		while (i > 0 && heap[i] < heap[Parent(i)])
		{
			Swap(i, Parent(i));
			i = Parent(i);
		}
	}

	private void HeapifyDown(int i)
	{
		int minIndex = i;
		int left = LeftChild(i);
		int right = RightChild(i);

		if (left < size && heap[left] < heap[minIndex])
		{
			minIndex = left;
		}

		if (right < size && heap[right] < heap[minIndex])
		{
			minIndex = right;
		}

		if (i != minIndex)
		{
			Swap(i, minIndex);
			HeapifyDown(minIndex);
		}
	}

	public void Insert(int value)
	{
		if (size == capacity)
		{
			return;
		}

		heap[size++] = value;
		HeapifyUp(size - 1);
	}

	public int ExtractMin()
	{
		if (size == 0)
		{
			return -1;
		}

		int min = heap[0];
		heap[0] = heap[size - 1];
		size--;
		HeapifyDown(0);

		return min;
	}

	public int GetMin()
	{
		if (size == 0) {
			return -1;
		}

		return heap[0];
	}

	public bool IsEmpty()
	{
		return size == 0;
	}
}