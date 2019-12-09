import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { EditFieldserviceComponent } from '../fieldservice/edit-fieldservice/edit-fieldservice.component';

@Injectable()
export class PreventUnsaveChanges implements CanDeactivate<EditFieldserviceComponent> {
    canDeactivate(component: EditFieldserviceComponent) {
        if (component.editForm.dirty) {
            return confirm('Are you sure you want to continue? Any unsaved changes will be lost.');
        }
        return true;
    }
}