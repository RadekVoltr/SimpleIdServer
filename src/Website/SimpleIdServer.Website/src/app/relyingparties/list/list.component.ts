import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { SearchResult } from '@app/stores/applications/models/search.model';
import * as fromReducers from '@app/stores/appstate';
import { startAdd, startSearch } from '@app/stores/relyingparties/actions/relyingparty.actions';
import { RelyingParty } from '@app/stores/relyingparties/models/relyingparty.model';
import { ScannedActionsSubject, select, Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { merge } from 'rxjs';
import { filter } from 'rxjs/operators';
import { AddRelyingPartyComponent } from './add-relyingparty.component';

@Component({
  selector: 'list-applications',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListRelyingPartiesComponent implements OnInit {
  displayedColumns: string[] = ['id', 'create_datetime', 'update_datetime'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  length: number;
  isLoading: boolean;
  relyingParties$: Array<RelyingParty> = [];

  constructor(
    private store: Store<fromReducers.AppState>,
    private dialog: MatDialog,
    private actions$: ScannedActionsSubject,
    private router: Router,
    private snackbar: MatSnackBar,
    private translateService: TranslateService) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.actions$.pipe(
      filter((action: any) => action.type === '[Applications] COMPLETE_ADD_RELYINGPARTY'))
      .subscribe((evt: any) => {
        this.snackbar.open(this.translateService.instant('relyingParties.messages.add'), this.translateService.instant('undo'), {
          duration: 2000
        });
        this.router.navigate(['/relyingparties/' + evt.id]);
      });
    this.actions$.pipe(
      filter((action: any) => action.type === '[Applications] ERROR_ADD_RELYINGPARTY'))
      .subscribe(() => {
        this.snackbar.open(this.translateService.instant('relyingParties.messages.errorAdd'), this.translateService.instant('undo'), {
          duration: 2000
        });
      });
    this.store.pipe(select(fromReducers.selectRelyingPartiesResult)).subscribe((state: SearchResult<RelyingParty> | null) => {
      if (!state || !state.content) {
        return;
      }

      this.relyingParties$ = state.content;
      this.length = state.totalLength;
      this.isLoading = false;
    });
  }

  ngAfterViewInit() {
    merge(this.sort.sortChange, this.paginator.page).subscribe(() => this.refresh());
    this.refresh();
  }

  refresh() {
    let startIndex: number = 0;
    let count: number = 5;
    if (this.paginator.pageIndex && this.paginator.pageSize) {
      startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    }

    if (this.paginator.pageSize) {
      count = this.paginator.pageSize;
    }

    let active = "create_datetime";
    let direction = "desc";
    if (this.sort.active) {
      active = this.sort.active;
    }

    if (this.sort.direction) {
      direction = this.sort.direction;
    }

    let request = startSearch({ order: active, direction, count, startIndex });
    this.store.dispatch(request);
  }

  addRelyingParty() {
    const dialogRef = this.dialog.open(AddRelyingPartyComponent, {
      width: '800px'
    });
    dialogRef.afterClosed().subscribe((opt : any) => {
      if (!opt) {
        return;
      }

      const addApp = startAdd({ metadataUrl: opt.metadataUrl });
      this.store.dispatch(addApp);
    });
  }
}
