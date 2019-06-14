import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'entity'})
export class EntityPipe implements PipeTransform {
  transform(value: boolean): string {
    return value ? "Business":"Individual";
  }
}