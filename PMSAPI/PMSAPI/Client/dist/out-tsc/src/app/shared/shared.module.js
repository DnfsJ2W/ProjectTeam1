/**
 * Created by andrew.yang on 7/27/2017.
 */
import { __decorate } from "tslib";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { QuantityControlComponent } from "../components/quantity-control/quantity-control.component";
let SharedModule = class SharedModule {
};
SharedModule = __decorate([
    NgModule({
        imports: [
            CommonModule,
            FormsModule,
        ],
        declarations: [
            QuantityControlComponent
        ],
        exports: [
            CommonModule,
            FormsModule,
            QuantityControlComponent
        ]
    })
], SharedModule);
export { SharedModule };
//# sourceMappingURL=shared.module.js.map