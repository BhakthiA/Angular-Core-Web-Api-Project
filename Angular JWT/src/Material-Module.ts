import { NgModule } from "@angular/core";
import{MatCardModule} from "@angular/material/card";
import{MatFormFieldModule} from "@angular/material/form-field";
import{MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button"
import {MatTableModule} from "@angular/material/table"
import {MatSelectModule} from "@angular/material/select"
import {MatDatepickerModule} from "@angular/material/datepicker"
import { MatNativeDateModule } from '@angular/material/core'
import {MatRadioModule} from "@angular/material/radio"
import { MatPaginatorModule } from '@angular/material/paginator';


@NgModule({
    exports:[
        MatCardModule,
        MatFormFieldModule,
        MatInputModule,
        MatInputModule,
        MatButtonModule,
        MatTableModule,
        MatSelectModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatRadioModule,
        MatPaginatorModule
    ]
})

export class MaterialModule{

}