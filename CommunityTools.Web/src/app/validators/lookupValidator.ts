import { Control } from "@angular/common";

interface ValidationResult {
  [key: string]: boolean;
}

export class LookupValidator {

  static notZero(control: Control): ValidationResult {

    if (control.value != "" && control.value == "0") {
      return { "notZero": true };
    }

    return null;
  }

  // static usernameTaken(control: Control): Promise<ValidationResult> {
  //
  //     return new Promise((resolve, reject) => {
  //         setTimeout(() => {
  //             if (control.value === "David") {
  //                 resolve({"usernameTaken": true})
  //             } else {
  //                 resolve(null);
  //             };
  //
  //         }, 1000);
  //     });
  //
  // }
}
