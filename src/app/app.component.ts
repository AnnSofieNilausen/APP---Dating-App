import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule to enable HTTP services
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Import FormsModule and ReactiveFormsModule for form handling

import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { MatchingComponent } from './components/matching/matching.component'; // Import the MatchingComponent
import { ProfileService } from './services/profile.service'; // Ensure the path to your service is correct
import { MatchingService } from './services/matching.service'; // Import the MatchingService

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,  // Declare ProfileComponent to be part of this module
    MatchingComponent  // Declare MatchingComponent to be part of this module
  ],
  imports: [
    BrowserModule,
    HttpClientModule,  // Include HttpClientModule to make it available throughout the app
    FormsModule,        // Include FormsModule for template-driven forms
    ReactiveFormsModule  // Include ReactiveFormsModule for reactive forms
  ],
  providers: [
    ProfileService,  // Add ProfileService to the list of providers if not using providedIn: 'root'
    MatchingService  // Add MatchingService to the list of providers if not using providedIn: 'root'
  ],
  bootstrap: [AppComponent]  // Bootstrap the AppComponent as the root component
})
export class AppModule { }
