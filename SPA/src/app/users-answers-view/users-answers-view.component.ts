import { Component, OnInit } from '@angular/core';
import { Answer, UserAnswers, UserService } from '../users.service';
import { Chart } from 'chart.js/auto';

@Component({
    selector: 'app-users-answers-view',
    templateUrl: './users-answers-view.component.html',
    styleUrls: ['./users-answers-view.component.css']
})
export class UsersAnswersComponent implements OnInit {
    userAnswers!: UserAnswers;
    public authChart: any;
    public oidcChart: any;
    public aadChart: any;
    public b2cChart: any;
    displayedColumns = ['status', 'description', 'edit', 'remove'];

    constructor(private service: UserService) { }

    ngOnInit(): void {
        this.getUsersAnswers();
    }

    getUsersAnswers(): void {
        this.service.getAnswers()
            .subscribe((answers: UserAnswers) => {
              this.userAnswers = answers
              this.createCharts();
            });
    }

    createCharts(){
      this.authChart = this.initializeChart("AuthenticationAnswerChart", "Do users know about authentication?", this.userAnswers.authenticationAnswers);
      this.oidcChart =this.initializeChart("OidcAnswerChart", "Do users know about OIDC?", this.userAnswers.oidcAnswers);
      this.aadChart =this.initializeChart("AadAnswerChart","Have users managed an Azure AD tenant?", this.userAnswers.aadAnswers);
      this.b2cChart =this.initializeChart("B2cAnswerChart", "Do users know about Azure B2C?", this.userAnswers.b2cAnswers);
    }
    
    initializeChart(id: string, label: string, answers: Answer){
      return new Chart(id, {
        type: 'pie', //this denotes tha type of chart
  
        data: {// values on X-Axis
          labels: ['Yes', 'No','No Answers' ],
             datasets: [{
      label: label,
      data: [answers.yes, answers.no, answers.noAnswer],
      backgroundColor: [
        'green',
        'red',
        'grey',		
      ],
      hoverOffset: 4
    }],
        },
        options: {
          aspectRatio: 8
        }
  
      });
    }
}
