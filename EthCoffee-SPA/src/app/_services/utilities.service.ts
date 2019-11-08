import { Injectable } from '@angular/core';
import { ListedDates } from '../_models/listing';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class UtilitiesService {
  constructor() {}

  convertListedDates(listedDate: ListedDates) {
    switch (listedDate) {
      case ListedDates.Today:
        return moment().format('YYYY-MM-DD');
      case ListedDates.Yesterday:
        return moment().subtract(1, 'days').format('YYYY-MM-DD');
      case ListedDates.ThisWeek:
        return moment().subtract(7, 'days').format('YYYY-MM-DD');
      case ListedDates.ThisMonth:
        return moment().subtract(30, 'days').format('YYYY-MM-DD');
      default:
        return moment().subtract(365, 'days').format('YYYY-MM-DD');
    }
  }
}
