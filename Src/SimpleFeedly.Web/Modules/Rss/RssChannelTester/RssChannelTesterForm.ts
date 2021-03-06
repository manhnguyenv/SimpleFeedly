﻿
namespace SimpleFeedly.Rss {

    @Serenity.Decorators.registerClass()
    export class RssChannelTesterForm extends Serenity.TemplatedWidget<any> {

        private templateHtml: string;

        constructor(container: JQuery) {
            super(container);

            this.templateHtml = this.byId("templateItems")[0].innerHTML;

            this.byId("btnCheck").click(() => this.CheckChannel(this.byId("txtChannelUrl").val()));
        }

        private CheckChannel(channelUrl: string) {

            if (Q.trimToNull(channelUrl) == null) {
                Q.warning("Please enter channel url");
                return;
            }

            RssChannelsService.TestChannel({ FeedUrl: channelUrl }, response => {
                console.log(response);

                if (response.Error != null) {
                    Q.alert(response.Error.Message);
                }
                else {
                    //var rendered = Mustache.render(this.byId('template').html(), { items : response.Entities });

                    var result: string = "";
                    response.Entities.forEach((item, idx) => {
                        result += this.templateHtml
                            .replace(/{{Link}}/g, item.Link)
                            .replace(/{{Title}}/g, item.Title);
                    });

                    console.log(result);
                    this.byId("postContainer").html(result);
                }
            });            
        }
    }
}