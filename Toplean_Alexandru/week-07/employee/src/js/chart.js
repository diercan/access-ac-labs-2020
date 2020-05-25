
			AmCharts.makeChart("chartdiv",
				{
					"type": "pie",
					"balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
					"titleField": "country",
					"valueField": "litres",
					"fontSize": 12,
					"theme": "chalk",
					"allLabels": [],
					"balloon": {},
					"titles": [],
					"dataProvider": [
						{
							"country": "Meniul Zilei",
							"litres": "356.9"
						},
						{
							"country": "Pizza",
							"litres": 131.1
						},
						{
							"country": "Clatite",
							"litres": 115.8
						},
						{
							"country": "Shaorma",
							"litres": 109.9
						},
						{
							"country": "Meniu Cascaval Pane",
							"litres": 108.3
						},
						{
							"country": "Meniu Vegan",
							"litres": 65
						},
						{
							"country": "Sushi",
							"litres": "20"
						}
					]
				}
			);
    
            
            AmCharts.makeChart("monthDiv",
				{
					"type": "pie",
					"balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
					"titleField": "country",
					"valueField": "litres",
					"fontSize": 12,
					"theme": "chalk",
					"allLabels": [],
					"balloon": {},
					"titles": [],
					"dataProvider": [
						{
							"country": "5 Stars",
							"litres": "556.9"
						},
						{
							"country": "4 Stars",
							"litres": 131.1
						},
						{
							"country": "3 Stars",
							"litres": 115.8
						},
						{
							"country": "2 Stars",
							"litres": 70.9
						},
						{
							"country": "1 star",
							"litres": 108.3
						}
					]
				}
			);