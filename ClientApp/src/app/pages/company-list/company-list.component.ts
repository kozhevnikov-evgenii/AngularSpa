import { Component, signal, inject, OnInit } from '@angular/core';
import { CompaniesService } from '../../services/companies.service';
import { Company } from '../../models/company';

@Component({
  selector: 'app-company-list',
  standalone: true,
  templateUrl: './company-list.component.html',
  styleUrl: './company-list.component.css'
})
export class CompanyListComponent implements OnInit {
  private companiesService = inject(CompaniesService);
  protected companies = signal<Company[]>([]);

  ngOnInit(): void {
    this.companiesService.getAll().subscribe(data => this.companies.set(data));
  }
}
