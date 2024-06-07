import { Component, OnInit } from '@angular/core';
import { FormsService } from '../../services/forms.service';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Form } from '../../interfaces/form';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, FormsModule, MatFormFieldModule, MatInputModule, MatExpansionModule, MatSelectModule, CommonModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss'
})
export class FormComponent implements OnInit {

  forms: Form[] = [];
  types: string[] = ['string', 'number', 'date'];

  /**
   *
   */
  constructor(private formService: FormsService) {
  }
  ngOnInit(): void {
    this.formService.getListForms().subscribe({
      next: (value) => {
        this.forms = value;
      },
    })
  }

  newForm(): void {
    this.forms.push(
      {
        id: 0,
        description: "Set your description",
        fields: [],
        name: "Set your name"
      }
    );
  }

  saveForm(form: Form): void {
    this.formService.saveForm(form).subscribe({
      next: (value) => {
        this.ngOnInit();
      },
    });
  }

  saveEditForm(form: Form): void {
    this.formService.saveEdit(form).subscribe({
      next: (value) => {
        this.ngOnInit();
      },
    });
  }

  delete(form: Form): void {
    this.formService.delete(form).subscribe({
      next: (value) => {
        this.ngOnInit();
      },
    });
  }

  addField(form: Form): void {
    if (!form.fields) {
      form.fields = [];
    }
    form.fields.push({
      content: "",
      formId: form.id,
      id: 0,
      title: "Insert Title",
      type: this.types.at(0) ?? ''
    });
  }

  deleteField(index: number, form: Form) {
    if (form.fields[index].id == 0) {
      form.fields.splice(index, 1);
    }
    else {
      this.formService.deleteField(form.fields[index].id).subscribe({
        next: (value) => {
          form.fields.splice(index, 1);
        },
      });
    }
  }

}
