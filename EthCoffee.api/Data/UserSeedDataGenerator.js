//Script for User Seed Data Generation: Use @ JSON Generator site:https://www.json-generator.com/
[
    '{{repeat(10)}}',
    {    
      Password: 'password',
      Firstname: '{{firstName()}}',
      Username: function(num){return this.Firstname + num.integer(11,99); },
      LastName: '{{surname()}}',
      Gender: '{{gender()}}',
      DateOfBirth: '{{date(new Date(1950,0,1), new Date(1999, 11, 31), "YYYY-MM-dd")}}',
      StreetNumber: '{{integer(100, 999)}}',
      Street: '{{street()}}',
      City: '{{city()}}',
      Country: '{{country()}}',
      ZipCode: '{{integer(100, 10000)}}',	
      Created: '{{date(new Date(2017,0,1), new Date(2017, 7, 31), "YYYY-MM-dd")}}',
      LastActive: function(){return this.Created; },
      Bio: '{{lorem(1, "sentences")}}',
      Interests: '{{lorem(1, "sentences")}}',
      Avatar:{
            url: function(num) {
            return 'https://randomuser.me/api/portraits/lego/' + num.integer(1,8) + '.jpg';
          },
          description: '{{lorem()}}'
          },    
      MyListings: [
          {
          Category: '{{random("Appliance > Kitchen", "Appliance > Laundry", "Appliance > Living")}}',
          Title: '{{lorem(1, "sentences")}}',
          Description: '{{lorem()}}',
          DateAdded: function(){return this.Created; },
          Photos: [
          {
            url: function(num) {
            return 'https://loremflickr.com/g/320/240/appliance';
          },
          isMain: true,
          description: '{{lorem()}}'
        }
      ]
        }
      ]
    }
  ]