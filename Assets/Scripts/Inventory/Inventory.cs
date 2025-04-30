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
	[SerializeField] private HQueue que;

	void Awake(){
		for(int i = 0; i < slots.Length; i++){
			que.push(i);
		}
	}

	public void AddItem(int id){
		if(inv.im[id].count == 0){
			inv.im[id].slot = slots[que.pop()];
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