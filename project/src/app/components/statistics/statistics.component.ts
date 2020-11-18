import { Component, OnInit } from '@angular/core';
import { ChartsModule, ThemeService } from 'ng2-charts';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import { StatisticsServiceService } from 'src/app/services/statistics-service.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss'],
  providers: [ThemeService]
})
export class StatisticsComponent implements OnInit {

  // Pie
  public pieChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: 'top',
    },
    plugins: {
      datalabels: {
        formatter: (value, ctx) => {
          const label = ctx.chart.data.labels[ctx.dataIndex];
          return label;
        },
      },
    }
  };
  public pieChartLabels: Label[] = [['נשים'], ['גברים']];
  public pieChartData: number[] = [300, 500];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [pluginDataLabels];
  public pieChartColors = [
    {
      backgroundColor: ['rgba(255,0,0,0.3)', 'rgba(94, 182, 209)'],
    },
  ];

  //bar
  public barChartOptions: ChartOptions = {
    responsive: true,
    // We use these empty structures as placeholders for dynamic theming.
    scales: { xAxes: [{}], yAxes: [{}] },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };

  public barChartLabels: Label[] = ['ראשון', 'שני', 'שלישי', 'רביעי', 'חמישי', 'שישי', 'מוצש"ק'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [pluginDataLabels];

  public barChartData: ChartDataSets[] = [
    { data: [], label: 'נשים' }
    ,
    { data: [], label: 'גברים' }
  ];

  //doughnut
  public doughnutChartLabels = ['מעל  20 ₪', '  ₪ בין 10 ל- 20  ', ' ₪ בין 5 ל-10 ', ' ₪ עד  5  '];
  public doughnutChartData  : number[] = [300, 500,400,98];
  public doughnutChartType = 'doughnut';
  public travelCost =[] ;
  avgPassengers:number;

  constructor(private statisticsService: StatisticsServiceService) { }

  ngOnInit() {
    let days: number[], i = 0;
    this.statisticsService.getTravelCost().subscribe
    (res =>  this.doughnutChartData=res   );
    this.statisticsService.getGender().subscribe(res => this.pieChartData = res);
    this.statisticsService.getAvgPassengers().subscribe(res => this.avgPassengers = res);
    this.statisticsService.getDays().subscribe
      (res => {
        days = res,
          days.forEach(element => {
            if (i >= 7)
              this.barChartData[1].data.push(element)
            else this.barChartData[0].data.push(element)
            i++
          })
        console.log(this.barChartData[1].data)
      });
  }

  // events
  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }



  // public randomize(): void {
  //   //this.barChartData[0].data ;
  // }
}
