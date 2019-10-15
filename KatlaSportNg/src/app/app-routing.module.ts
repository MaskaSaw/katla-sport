import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from 'app/main-page/main-page.component';
import { HiveFormComponent } from './hive-management/forms/hive-form.component';
import { HiveSectionFormComponent } from './hive-management/forms/hive-section-form.component';
import { HiveListComponent } from './hive-management/lists/hive-list.component';
import { HiveSectionListComponent } from './hive-management/lists/hive-section-list.component';
import { ProductCategoryFormComponent } from './product-management/forms/product-category-form.component';
import { ProductFormComponent } from './product-management/forms/product-form.component';
import { ProductCategoryListComponent } from './product-management/lists/product-category-list.component';
import { ProductCategoryProductListComponent } from './product-management/lists/product-category-product-list.component';
import { ProductListComponent } from './product-management/lists/product-list.component';
import { ClientListComponent } from './client-management/lists/client-list.component';
import { ClientFormComponent } from './client-management/form/client-form.component';
import { OrderListComponent } from './order-management/lists/order-list.component';
import { OrderFormComponent } from './order-management/form/order-form.component';
import { ManagerListComponent } from './manager-management/lists/manager-list.component';
import { ManagerFormComponent } from './manager-management/form/manager-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainPageComponent },
  { path: 'categories', component: ProductCategoryListComponent },
  { path: 'category', component: ProductCategoryFormComponent },
  { path: 'category/:id', component: ProductCategoryFormComponent },
  { path: 'category/:id/products', component: ProductCategoryProductListComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'product/:id', component: ProductFormComponent },
  { path: 'category/:categoryId/product/:id', component: ProductFormComponent },
  { path: 'hives', component: HiveListComponent },
  { path: 'hive', component: HiveFormComponent },
  { path: 'hive/:id', component: HiveFormComponent },
  { path: 'hive/:id/sections', component: HiveSectionListComponent },
  { path: 'section/:id', component: HiveSectionFormComponent },
  { path: 'hive/:id/section/:sectionId', component: HiveSectionFormComponent },
  { path: 'hive/:id/section', component: HiveSectionFormComponent },
  { path: 'clients', component: ClientListComponent },
  { path: 'client/:id', component: ClientFormComponent },
  { path: 'client', component: ClientFormComponent },
  { path: 'orders', component: OrderListComponent },
  { path: 'order/:id', component: OrderFormComponent },
  { path: 'order', component: OrderFormComponent },
  { path: 'managers', component: ManagerListComponent },
  { path: 'manager/:id', component: ManagerFormComponent },
  { path: 'manager', component: ManagerFormComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
