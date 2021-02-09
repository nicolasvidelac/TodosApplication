import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { todoItem } from "src/app/models/todoItem";

@Component({
    selector: 'app-item-form',
    templateUrl: './form-item.component.html',
  })
  
  export class ItemFormComponent {
    constructor(
      public dialogRef: MatDialogRef<ItemFormComponent>,
      @Inject(MAT_DIALOG_DATA) public data: todoItem) {}
  }