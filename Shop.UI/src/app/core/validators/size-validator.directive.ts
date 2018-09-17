import { AbstractControl } from '@angular/forms';

export function forbiddenNameValidator(control: AbstractControl) {
  if (control.value) {
    if (!(control.value === 'null')) {
      return null;
    }
  }
  return { validSize: true};
}
