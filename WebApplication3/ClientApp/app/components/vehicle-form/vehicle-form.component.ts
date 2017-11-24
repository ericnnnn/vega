import { Component, OnInit } from '@angular/core';
import { MakeService } from '../../services/make.service';
import { FeatureService } from '../../services/feature.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  
  private features: any[];

  private makes:any[];
  private models:any[];
  private vehicle:any={};
  constructor(private makeService: MakeService,
              private featureService: FeatureService ) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(makes=>{
      this.makes=makes;
      //console.log('Makes:',this.makes);

    this.featureService.getFeatures().subscribe(features=>
      this.features=features);
      
    });
  }

  onMakeChange(){
    //console.log("vehicle:",this.vehicle);
    var selectedMake=this.makes.find(m=>m.id==this.vehicle.make);
    //console.log('selectedMake',selectedMake);
    this.models=selectedMake?selectedMake.models:[];
  }
}
