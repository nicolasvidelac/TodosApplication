import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { todoFolder } from "src/app/models/todofolder";

@Component({
    selector: 'app-folder-form',
    templateUrl: './form-folder.component.html',
  })
  
  export class FolderFormComponent {
    constructor(
      public dialogRef: MatDialogRef<FolderFormComponent>,
      @Inject(MAT_DIALOG_DATA) public data: todoFolder) {}
  }