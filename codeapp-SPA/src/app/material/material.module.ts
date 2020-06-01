import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as Material from '@angular/material';
import { MatButtonModule, MatDatepicker, MatDialogRef } from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    Material.MatToolbarModule,
    Material.MatTableModule,
    Material.MatGridListModule,
    Material.MatFormFieldModule,
    Material.MatInputModule,
    Material.MatRadioModule,
    Material.MatSelectModule,
    Material.MatPaginatorModule,
    Material.MatSortModule,
    Material.MatProgressSpinnerModule,
    Material.MatCheckboxModule,
    Material.MatIconModule,
    Material.MatDialogModule,
    Material.MatButtonModule,
    Material.MatDatepickerModule,
    Material.MatNativeDateModule

  ],
  exports: [
    Material.MatToolbarModule,
    Material.MatTableModule,
    Material.MatGridListModule,
    Material.MatFormFieldModule,
    Material.MatInputModule,
    Material.MatRadioModule,
    Material.MatSelectModule,
    Material.MatPaginatorModule,
    Material.MatSortModule,
    Material.MatProgressSpinnerModule,
    Material.MatCheckboxModule,
    Material.MatIconModule,
    Material.MatDialogModule,
    Material.MatButtonModule,
    Material.MatDatepickerModule,
    Material.MatNativeDateModule

  ]
})
export class MaterialModule { }
